namespace contoso_pizza_backend.Models.DTO.Response

{

    public partial class ResponseSuccess : Response
    {
        public ResponseSuccess(string description, string descTranslate)
        {
            this.success = true;
            this.description = description;
            this.descTranslate = descTranslate;
            this.status = 200;
        }
    }

}

