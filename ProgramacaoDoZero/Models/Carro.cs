namespace ProgramacaoDoZero.Models
{
    public class Carro : Veiculo
    {

        //construtores permitem criar objetos da classe e definir valores padrão, limitando também, a instanciação.
        public Carro()
        {
            QuantidadeRodas = 4;
        }

        public int QuantidadeRodas { get; set; }

        //"override" sobrescreve o método Acelerar da classe mãe Veiculo
        public override void Acelerar()
        {
            InjetarCombustivel(4);
        }

        private void InjetarCombustivel(int quantidadeCombustivel)
        {
            //"base" acessa atributos e métodos da classe mãe         
            base.TanqueCombustivel = base.TanqueCombustivel - quantidadeCombustivel;
        }
    }
}
