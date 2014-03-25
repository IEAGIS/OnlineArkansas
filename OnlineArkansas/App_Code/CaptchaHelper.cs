using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BotDetect.Web.UI.Mvc;

namespace OnlineArkansas.App_Code
{
    public class CaptchaHelper
    {
        public static MvcCaptcha GetSampleCaptcha()
        {
            // create the control instance
            MvcCaptcha sampleCaptcha = new MvcCaptcha("SampleCaptcha");

            // set up client-side processing of the Captcha code input textbox
            sampleCaptcha.UserInputClientID = "CaptchaCode";

            return sampleCaptcha;
        }
    }
}