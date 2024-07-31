namespace ProgramacaoDoZero.Models
{
    public class Moto : Veiculo 
    {
        public Moto()
        {
            QuantidadeRodas = 2;

            TanqueCombustivel = 15; //sobrescrição do "TanqueCombustivel" da classe mãe
        }

        public override void Acelerar()
        {
            InjetarCombustivel(1);
        }

        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadeCombustivel;
        }
    
        public int QuantidadeRodas { get; set; }
    }
}
