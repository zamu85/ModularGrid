using System.Collections.Generic;
using System.Linq;
using Commonality.Dto.Messages;
using Commonality.Dto.Patient;
using DevExpress.Mvvm;
using Services.Patient;

namespace View.ViewModel.Patient
{
    public class PatientViewModel
    {
        private readonly PatientService _patientService;
        private PatientDto _selectedPatient;

        public PatientViewModel(PatientService patientService)
        {
            _patientService = patientService;

            //_patientService.Add(new PatientDto()
            //{
            //    BirthDate = System.DateTime.Now,
            //    FirstName = "Riccardo",
            //    LastName = "Zamuner"
            //});

            Patients = _patientService.GetAllPatient().ToList();
        }

        public IList<PatientDto> Patients { get; }

        public PatientDto SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                Messenger.Default.Send<PatientMessage>(new PatientMessage(_selectedPatient.PatientId));
            }
        }
    }
}
