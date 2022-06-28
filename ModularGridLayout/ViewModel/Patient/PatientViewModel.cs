using System.Collections.Generic;
using Commonality.Dto.Patient;
using Services.Patient;

namespace View.ViewModel.Patient
{
    public class PatientViewModel : IProxyPatientViewModel
    {
        private readonly PatientService _patientService;

        public PatientViewModel(PatientService patientService)
        {
            _patientService = patientService;

            //_patientService.Add(new PatientDto()
            //{
            //    BirthDate = System.DateTime.Now,
            //    FirstName = "Riccardo",
            //    LastName = "Zamuner"
            //});

            // Patients = _patientService.GetAllPatient().ToList();
        }

        //private PatientDto _selectedPatient;
        //public IList<PatientDto> Patients { get; }

        //public PatientDto SelectedPatient
        //{
        //    get { return _selectedPatient; }
        //    set
        //    {
        //        _selectedPatient = value;
        //        Messenger.Default.Send<PatientMessage>(new PatientMessage(_selectedPatient.PatientId));
        //    }
        //}

        public IEnumerable<PatientDto> GetAll()
        {
            return _patientService.GetAllPatientsWithExams();
        }
    }
}
