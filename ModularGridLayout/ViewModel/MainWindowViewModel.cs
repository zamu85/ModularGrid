using Commonality.Dto.Exam;
using Commonality.Dto.File;
using Commonality.Dto.Messages;
using Commonality.Dto.Patient;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Editors;
using Services.Exam;
using Services.File;
using Services.Patient;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using View.ViewModel.Exam;
using View.ViewModel.File;
using View.ViewModel.Patient;

namespace View.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IProxyPatientViewModel _patientModel;
        private IList<PatientDto> _patients;
        private IProxyExamViewModel _proxyExamViewModel;
        private IProxyFileViewModel _proxyFileViewModel;
        private IList<PatientNameDto> _quickSearchPatients;
        private ExamDto _selectedExam;
        private int _selectedLayout = 1;
        private PatientDto _selectedPatient;

        public MainWindowViewModel(PatientService patientService, ExamService examService, FileService fileService)
        {
            ChangeLayoutCommand = new DelegateCommand<int>(ChangeLayout, CanChangeLayout);
            Messenger.Default.Send<ChangeLayout>(new ChangeLayout(_selectedLayout));

            _patientModel = new ProxyPatientViewModel(patientService);
            _proxyExamViewModel = new ProxyExamViewModel(examService);
            _proxyFileViewModel = new ProxyFileViewModel(fileService);

            LoadPatients();
        }

        public DelegateCommand<int> ChangeLayoutCommand { get; set; }

        public ObservableCollection<ExamDto> Exams { get; } = new ObservableCollection<ExamDto>();

        public ObservableCollection<FileDto> Files { get; } = new ObservableCollection<FileDto>();

        public bool IsExpandButtonVisible => _selectedLayout > 1;

        public ObservableCollection<PatientDto> Patients { get; } = new ObservableCollection<PatientDto>();

        public ObservableCollection<PatientNameDto> QuickSearchPatients { get; } = new();

        public ExamDto SelectedExam
        {
            get { return _selectedExam; }
            set
            {
                _selectedExam = value;
                if (value != null)
                {
                    LoadFilesForExam(value);
                }
            }
        }

        public int SelectedLayout
        {
            get { return _selectedLayout; }
        }

        public PatientDto SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                if (value is not null)
                {
                    LoadExamForPatient(value);
                }
            }
        }

        public bool CanChangeLayout(int selectedLayout) => true;

        public void ChangeLayout(int selectedLayout)
        {
            _selectedLayout = selectedLayout;
            RaisePropertiesChanged("SelectedLayout");
        }

        [Command]
        public void ChosenPatient(AutoSuggestEditSuggestionChosenEventArgs parameter)
        {
            var patient = _patientModel.Get(((PatientNameDto)parameter.SelectedItem).PatientId);
            Patients.Clear();
            Patients.Add(patient);
        }

        [Command]
        public async void QueryPatients(AutoSuggestEditQuerySubmittedEventArgs parameter)
        {
            if (string.IsNullOrEmpty(parameter.Text))
            {
                ResetQuickSearch();
                return;
            }

            if (parameter.Text.Length < 3)
            {
                return;
            }

            QuickSearchPatients.Clear();
            var quickSearchPatients = await _patientModel.QuickSearchPatients(parameter.Text);
            _quickSearchPatients = quickSearchPatients.ToList();
            quickSearchPatients.ForEach(QuickSearchPatients.Add);
        }

        [Command]
        public void ResetQuickSearch()
        {
            if (_quickSearchPatients is null)
            {
                return;
            }

            QuickSearchPatients.Clear();
            _quickSearchPatients.Clear();

            Patients.Clear();
            LoadPatients();
            return;
        }

        private void LoadExamForPatient(PatientDto patient)
        {
            Exams.Clear();
            Files.Clear();

            if (_selectedLayout < 3)
            {
                _proxyExamViewModel.GetAll(patient.PatientId).ForEach(Exams.Add);
            }
        }

        private void LoadFilesForExam(ExamDto value)
        {
            Files.Clear();
            _proxyFileViewModel.GetAll(value.ExamId).ForEach(Files.Add);
        }

        private void LoadPatients()
        {
            _patients = _patientModel.GetAll().ToList();
            _patients.ForEach(Patients.Add);
        }
    }
}
