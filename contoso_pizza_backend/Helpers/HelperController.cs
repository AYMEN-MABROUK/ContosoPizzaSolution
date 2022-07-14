namespace contoso_pizza_backend.Helpers
{
    public static class HelperController {

        public static int getLanguageCode(string lang) 
        {
            if(string.IsNullOrEmpty(lang)) return ((int)Languages.fr);
            if(lang.ToUpper()=="AR" || lang.ToUpper()=="ARABIC"){
                return ((int)Languages.ar);
            }else{
                return ((int)Languages.fr); //Default French
            }
        }

    }
}