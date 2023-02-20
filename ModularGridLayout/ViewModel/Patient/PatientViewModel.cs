using Commonality.Dto.Patient;
using Services.Patient;
using System;
using System.Collections.Generic;

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

        public void Get(int patientId)
        {
            throw new NotImplementedException();
        }

        PatientDto IProxyPatientViewModel.Get(int patientId)
        {
            return _patientService.Get(patientId);
        }

        public IEnumerable<PatientDto> GetAll()
        {
            return _patientService.GetAllPatientsWithExams();
        }

        public IEnumerable<PatientNameDto> QuickSearchPatients(string text)
        {
            return _patientService.QuickSearchPatient(text);
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
    }
}
