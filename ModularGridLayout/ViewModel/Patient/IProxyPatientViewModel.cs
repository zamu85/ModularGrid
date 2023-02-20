using Commonality.Dto.Patient;
using System.Collections.Generic;

namespace View.ViewModel.Patient
{
    internal interface IProxyPatientViewModel
    {
        PatientDto Get(int patientId);

        IEnumerable<PatientDto> GetAll();

        IEnumerable<PatientNameDto> QuickSearchPatients(string text);
    }
}
