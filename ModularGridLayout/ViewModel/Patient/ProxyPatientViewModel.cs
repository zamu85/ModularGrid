using System.Collections.Generic;
using Commonality.Dto.Patient;
using Services.Patient;

namespace View.ViewModel.Patient
{
    public class ProxyPatientViewModel : IProxyPatientViewModel
    {
        private readonly PatientService _patientService;

        private IEnumerable<PatientDto> _allPatient;
        private PatientViewModel _patientViewModel;

        public ProxyPatientViewModel(PatientService patientService)
        {
            _patientService = patientService;
            _patientViewModel = new PatientViewModel(patientService);
        }

        public IEnumerable<PatientDto> GetAll()
        {
            if (_allPatient != null)
            {
                return _allPatient;
            }

            _allPatient = _patientViewModel.GetAll();
            return _allPatient;
        }
    }
}
