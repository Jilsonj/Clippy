using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CLIPPY.NET.Executers
{
    public class JsonFormatter : IBaseExecuter
    {
        public bool CanExecute(string inputText)
        {
            try
            {
                var json = JContainer.Parse(inputText);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Execute(string json)
        {
            //return JsonConvert.SerializeObject(inputText, Formatting.Indented);

            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}
