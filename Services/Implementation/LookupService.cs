using ProyectoBackendMINIDOC.Mappers;
using ProyectoBackendMINIDOC.Models.Dtos.MinidocNew.Lookups;
using ProyectoBackendMINIDOC.Repositories.Interfaces;
using ProyectoBackendMINIDOC.Services.Interfaces;

namespace ProyectoBackendMINIDOC.Services.Implementation
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _repository;

        public LookupService(ILookupRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<JerarquiaDTO>> GetJerarquiasAsync() =>
            (await _repository.GetJerarquiasAsync()).Select(LookupMapper.ToDTO);

        public async Task<IEnumerable<CuerpoDTO>> GetCuerposAsync() =>
            (await _repository.GetCuerposAsync()).Select(LookupMapper.ToDTO);

        public async Task<IEnumerable<EscalafonDTO>> GetEscalafonesAsync() =>
            (await _repository.GetEscalafonesAsync()).Select(LookupMapper.ToDTO);

        public async Task<IEnumerable<TipoClasificacionDTO>> GetTiposClasificacionAsync() =>
            (await _repository.GetTiposClasificacionAsync()).Select(LookupMapper.ToDTO);

        public async Task<IEnumerable<EstadoDTO>> GetEstadosAsync() =>
            (await _repository.GetEstadosAsync()).Select(LookupMapper.ToDTO);

        public async Task<IEnumerable<DestinoDTO>> GetDestinosAsync() =>
            (await _repository.GetDestinosAsync()).Select(LookupMapper.ToDTO);

        public async Task<IEnumerable<NivelDTO>> GetNivelesAsync() =>
            (await _repository.GetNivelesAsync()).Select(LookupMapper.ToDTO);

        public async Task<LookupsResponseDTO> GetAllLookupsAsync()
        {
            var response = new LookupsResponseDTO
            {
                Jerarquias = (await _repository.GetJerarquiasAsync()).Select(LookupMapper.ToDTO).ToList(),
                Cuerpos = (await _repository.GetCuerposAsync()).Select(LookupMapper.ToDTO).ToList(),
                Escalafones = (await _repository.GetEscalafonesAsync()).Select(LookupMapper.ToDTO).ToList(),
                TiposClasificacion = (await _repository.GetTiposClasificacionAsync()).Select(LookupMapper.ToDTO).ToList(),
                Estados = (await _repository.GetEstadosAsync()).Select(LookupMapper.ToDTO).ToList(),
                Destinos = (await _repository.GetDestinosAsync()).Select(LookupMapper.ToDTO).ToList(),
                Niveles = (await _repository.GetNivelesAsync()).Select(LookupMapper.ToDTO).ToList()
            };
            return response;
        }
    }
}
