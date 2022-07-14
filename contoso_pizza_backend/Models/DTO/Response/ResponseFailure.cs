namespace contoso_pizza_backend.Models.DTO.Response

{
    public partial class ResponseFailure : Response

    {
        public ResponseFailure(string description, string descTranslate)
        {
            this.success = false;
            this.description = description;
            this.descTranslate = descTranslate;
            this.status = 409;
        }
        public ResponseFailure(string description, string descTranslate, int status)
        {
            this.success = false;
            this.description = description;
            this.descTranslate = descTranslate;
            this.status = status;
        }

    }

}

