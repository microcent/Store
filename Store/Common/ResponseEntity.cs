using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Reflection;

namespace Store.Common
{
    public class ResponseEntity
    {
        public ResponseStatus Status { get; set; }
        public object Response { get; set; }

        public ResponseEntity(ResponseStatus status)
        {
            this.Status = status;

            FieldInfo fi = status.GetType().GetField(status.ToString());
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            this.Response = arrDesc[0].Description;
        }

        public ResponseEntity(ResponseStatus status, object response)
        {
            this.Status = status;
            this.Response = response;
        }

        public static ResponseEntity success()
        {
            return new ResponseEntity(ResponseStatus.SUCCESS);
        }

        public static ResponseEntity success(object response)
        {
            return new ResponseEntity(ResponseStatus.SUCCESS, response);
        }

        public static ResponseEntity failure()
        {
            return new ResponseEntity(ResponseStatus.ERROR);
        }

        public static ResponseEntity failure(object response)
        {
            return new ResponseEntity(ResponseStatus.ERROR, response);
        }
    }
}