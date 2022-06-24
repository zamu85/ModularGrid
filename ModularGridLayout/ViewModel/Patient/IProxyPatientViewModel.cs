using System.Collections.Generic;
using Commonality.Dto.Patient;

namespace View.ViewModel.Patient
{
    internal interface IProxyPatientViewModel
    {
        IEnumerable<PatientDto> GetAll();
    }
}
