using Commonality.Dto.Patient;
using DevExpress.Data.Filtering;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Xpf;
using DevExpress.Xpf.Data;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using Services.Patient;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using View.EventArgs;
using View.ViewModel.Patient;

namespace View.ViewModel.CustomComponent
{
    public class QuickSearchViewModel : ViewModelBase
    {
        private static string[] Properties = new string[] { "FullName", "ReverseName" };
        private IProxyPatientViewModel _patientModel;
        private PatientService _patientService;

        public QuickSearchViewModel(PatientService patientService)
        {
            _patientModel = new ProxyPatientViewModel(patientService);
            _patientService = patientService;
        }

        public bool IsCloseButtonVisible { set; get; } = false;

        [Command]
        public void ChosenPatient(AutoSuggestEditSuggestionChosenEventArgs parameter)
        {
            var patient = _patientModel.Get(((PatientNameDto)parameter.SelectedItem).PatientId);
            /// send message for chosen patient
        }

        [Command]
        public void FetchRows(FetchRowsAsyncArgs e)
        {
            e.Result = FetchRowsAsync(e);
        }

        [Command]
        public void PopupOpened(AutoSuggestEditQueryWithSenderArgs e)
        {
            if (e.Sender is AutoSuggestEdit ase)
            {
                if (ase.EditText.Length < 3)
                {
                    return;
                }
                AssignFilter(ase, ase.EditText);
            }
        }

        [Command]
        public void QuerySubmitted(AutoSuggestEditQueryWithSenderArgs e)
        {
            string text = e.AutoSuggestEditQuerySubmittedEventArgs.Text;
            IsCloseButtonVisible = text.Length > 0;
            RaisePropertiesChanged("IsCloseButtonVisible");

            if (text.Length < 3)
            {
                return;
            }

            if (e.Sender is AutoSuggestEdit ase)
            {
                AssignFilter(ase, text);
            }
        }

        [Command]
        public void ResetQuickSearch()
        {
            /// send message for cleared selection
            IsCloseButtonVisible = false;
            RaisePropertiesChanged("IsCloseButtonVisible");
            return;
        }

        private static void AssignFilter(AutoSuggestEdit editor, string searchString)
        {
            if (editor.PopupElement is GridControl grid)
            {
                grid.FixedFilter = GetFilter(searchString);
            }
        }

        private static CriteriaOperator GetFilter(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            return new GroupOperator(GroupOperatorType.Or, Properties.Select(prov =>
                new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty(prov), new OperandValue(text))));
        }

        private async Task<FetchRowsResult> FetchRowsAsync(FetchRowsAsyncArgs e)
        {
            if (ReferenceEquals(e.Filter, null))
            {
                return new FetchRowsResult(null, false);
            }

            var queryable = await GetIssueDataQueryable();

            var fetched = queryable
                .Where(MakeFilterExpression((CriteriaOperator)e.Filter))
                .Skip(e.Skip)
                .Take(30)
                .OrderBy(p => p.FirstName)
                .ToArray();

            return new FetchRowsResult(rows: fetched);
        }

        private async Task<IQueryable<PatientNameDto>> GetIssueDataQueryable()
        {
            return await _patientService.QuickSearch();
        }

        private Expression<Func<PatientNameDto, bool>> MakeFilterExpression(CriteriaOperator filter)
        {
            var converter = new GridFilterCriteriaToExpressionConverter<PatientNameDto>();
            return converter.Convert(filter);
        }
    }
}
