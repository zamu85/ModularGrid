using Commonality.Dto.Patient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace View.ViewModel.Patient
{
    internal interface IProxyPatientViewModel
    {
        PatientDto Get(int patientId);

        IEnumerable<PatientDto> GetAll();

        Task<IEnumerable<PatientNameDto>> QuickSearchPatients(string text);
    }
}
