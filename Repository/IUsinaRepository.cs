﻿using DTO.Usina;

namespace Repository
{
    public interface IUsinaRepository
    {
        Task RegistrarEntradaUsina(EntradaUsinaDto entradaUsina);

        Task RegistrarSaidaUsina(SaidaUsinaDto entradaUsina);

        Task RegistrarEstoqueCap(EstoqueCapDto estoqueCap);

        Task<IEnumerable<SaidaUsinaCompletaDto>> ListarSaidaUsina(DateTime DataSaidaInicio, DateTime DataSaidaFim);

        Task<IEnumerable<EntradaUsinaCompletaDto>> ListarEntradaUsina(DateTime dataEntradaInicio, DateTime dataEntradaFim);
    }
}
