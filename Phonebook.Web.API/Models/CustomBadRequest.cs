using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Phonebook.Web.API.Models
{
    public class CustomBadRequest
    {
        [JsonProperty("errorcode")]
        public int ErrorCode { get; set; }

        [JsonProperty("errormessage")]
        public string ErrorMessage { get; set; }

        [JsonProperty("errors")]
        public Dictionary<string, string[]> Errors { get; set; }

        public CustomBadRequest()
        {

        }

        public CustomBadRequest(ActionContext context)
        {
            this.ErrorCode = StatusCodes.Status400BadRequest;
            this.ErrorMessage = "The inputs supplied to the API are invalid";
            this.Errors = new Dictionary<string, string[]>();
            this.ConstructErrorMessages(context);
        }

        private void ConstructErrorMessages(ActionContext context)
        {
            foreach (var keyModelStatePair in context.ModelState)
            {
                var key = keyModelStatePair.Key;
                var errors = keyModelStatePair.Value.Errors;
                if (errors != null && errors.Count > 0)
                {
                    if (errors.Count == 1)
                    {
                        var errorMessage = GetErrorMessage(errors[0]);
                        Errors.Add(key, new[] { errorMessage });
                    }
                    else
                    {
                        var errorMessages = new string[errors.Count];
                        for (var i = 0; i < errors.Count; i++)
                        {
                            errorMessages[i] = GetErrorMessage(errors[i]);
                        }

                        Errors.Add(key, errorMessages);
                    }
                }
            }

            string GetErrorMessage(ModelError error)
            {
                return string.IsNullOrEmpty(error.ErrorMessage) ?
                    "The input was not valid." :
                error.ErrorMessage;
            }
        }
    }
}
