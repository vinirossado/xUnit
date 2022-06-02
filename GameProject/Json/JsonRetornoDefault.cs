using FluentValidation.Results;
using Newtonsoft.Json;

namespace GameProject.Json

{
    public class JsonRetornoDefault
    {
        #region Properties
        public List<JsonRetornoErro> Erros { get; private set; }
        #endregion

        #region Constructors

        public JsonRetornoDefault(string mensagem)
        {
            this.Erros = new List<JsonRetornoErro>();
            this.Erros.Add(new JsonRetornoErro(mensagem));
        }

        public JsonRetornoDefault(JsonRetornoErro erro)
        {
            this.Erros = new List<JsonRetornoErro>();
            if (erro != null) this.Erros.Add(erro);
        }

        public JsonRetornoDefault(IList<JsonRetornoErro> erros)
        {
            this.Erros = new List<JsonRetornoErro>();
            if (erros != null) this.Erros = erros.ToList();
        }

        public JsonRetornoDefault(IList<ValidationFailure> erros)
        {
            this.Erros = new List<JsonRetornoErro>();
            if (erros != null) SetErrosPorValidationFailure(erros.ToList());
        }

        public JsonRetornoDefault(IList<DomainNotification> erros)
        {
            this.Erros = new List<JsonRetornoErro>();
            if (erros != null) SetErrosPorNotification(erros.ToList());
        }

        #endregion

        #region Métodos
        public string ToJsonString()
        {
            return JsonConvert.SerializeObject(this);
        }

        private void SetErrosPorValidationFailure(List<ValidationFailure> erros)
        {
            foreach (var erro in erros)
            {
                this.Erros.Add(new JsonRetornoErro(erro.PropertyName, erro.ErrorMessage));
            }
        }

        private void SetErrosPorNotification(List<DomainNotification> erros)
        {
            foreach (var erro in erros)
            {
                this.Erros.Add(new JsonRetornoErro(erro.Key, erro.Value));
            }
        }

        #endregion

    }
}
