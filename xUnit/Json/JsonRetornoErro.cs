namespace Game.Json

{
    public class JsonRetornoErro
    {
        public string Propriedade { get; set; }
        public string Mensagem { get; set; }

        public JsonRetornoErro(string propriedade, string mensagem)
        {
            this.Propriedade = propriedade;
            this.Mensagem = mensagem;
        }

        public JsonRetornoErro(string message)
        {
            this.Mensagem = message;
        }
    }
}
