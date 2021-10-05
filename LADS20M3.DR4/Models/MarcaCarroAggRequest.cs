namespace LADS20M3.DR4.Models
{
    public class MarcaCarroAggRequest
    {
        public MarcaViewModel Marca { get; set; }
        public CarroViewModel Carro { get; set; }

        public MarcaCarroAggRequest(MarcaCarroCreateViewModel marcaCarroCreateViewModel)
        {
            Carro = new CarroViewModel
            {
                Modelo = marcaCarroCreateViewModel.Modelo,
                Ano = marcaCarroCreateViewModel.Ano,
                Portas = marcaCarroCreateViewModel.Portas,
                Cambio = marcaCarroCreateViewModel.Cambio,
                Direcao = marcaCarroCreateViewModel.Direcao,
                Lancamento = marcaCarroCreateViewModel.Lancamento,
                MarcaId = marcaCarroCreateViewModel.MarcaId ?? 0
            };

            if(Carro.MarcaId > 0)
            {
                return;
            }

            Marca = new MarcaViewModel
            {
                Nome = marcaCarroCreateViewModel.Nome,
                PaisFundacao = marcaCarroCreateViewModel.PaisFundacao,
                NomeFundador = marcaCarroCreateViewModel.NomeFundador,
                DiaFundacao = marcaCarroCreateViewModel.DiaFundacao ?? default
            };
        }
    }
}
