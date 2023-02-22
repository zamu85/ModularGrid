using Commonality.Dto.Patient;
using DevExpress.Data.Filtering;
using DevExpress.Xpf.Data;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using Services.Patient;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;

namespace View.View.Test
{
    /// <summary>
    /// Interaction logic for TestAutoSuggest.xaml
    /// </summary>
    public partial class TestAutoSuggest : Window
    {
        private static PatientService _patientService;
        private static string[] Properties = new string[] { "FullName", "ReverseName" };
        // private static char[] Separators = new char[] { ' ', ',', ';' };

        public TestAutoSuggest(PatientService patientService)
        {
            InitializeComponent();
            var source = new InfiniteAsyncSource() { ElementType = typeof(PatientNameDto) };
            source.FetchRows += (o, e) => e.Result = Task.Run(async () => await FetchRows(e));
            autoSuggestEdit.ItemsSource = source;
            // Closing += (o, e) => source.Dispose();
            _patientService = patientService;
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

            //var values = text.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            //if (values.Length == 0)
            //{
            //    return null;
            //}

            //return new GroupOperator(GroupOperatorType.Or, Properties.SelectMany(prov => values.Select(val => new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty(prov), new OperandValue(val)))));

            return new GroupOperator(GroupOperatorType.Or, Properties.Select(prov =>
                new FunctionOperator(FunctionOperatorType.Contains, new OperandProperty(prov), new OperandValue(text))));
        }

        private static async Task<IQueryable<PatientNameDto>> GetIssueDataQueryable()
        {
            //var context = new SCEntities(new Uri("https://demos.devexpress.com/Services/WcfLinqSC/WcfSCService.svc/"));
            //return context.PatientNameDto;
            return await _patientService.QuickSearch();
        }

        private static Expression<Func<PatientNameDto, bool>> MakeFilterExpression(CriteriaOperator filter)
        {
            var converter = new GridFilterCriteriaToExpressionConverter<PatientNameDto>();
            return converter.Convert(filter);
        }

        private async Task<FetchRowsResult> FetchRows(FetchRowsAsyncEventArgs e)
        {
            if (ReferenceEquals(e.Filter, null))
            {
                return new FetchRowsResult(null, false);
            }

            var queryable = await GetIssueDataQueryable();

            return queryable
                .Where(MakeFilterExpression(e.Filter))
                .Skip(e.Skip)
                .Take(30)
                .OrderBy(p => p.FirstName)
                .ToArray();
        }

        private void PopupOpened(object sender, RoutedEventArgs e)
        {
            if (autoSuggestEdit.EditText.Length < 3)
            {
                return;
            }
            AssignFilter(autoSuggestEdit, autoSuggestEdit.EditText);
        }

        private void QuerySubmitted(object sender, AutoSuggestEditQuerySubmittedEventArgs e)
        {
            if (e.Text.Length < 3)
            {
                return;
            }
            AssignFilter(autoSuggestEdit, e.Text);
        }
    }
}
