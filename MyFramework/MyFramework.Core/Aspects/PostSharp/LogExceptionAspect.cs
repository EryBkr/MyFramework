﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MyFramework.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
namespace MyFramework.Core.Aspects.PostSharp
{
    [Serializable]
   public class LogExceptionAspect:OnExceptionAspect
    {
        private LoggerService _loggerService;
        private Type _loggerType;

        public LogExceptionAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (_loggerType!=null)
            {
                if (_loggerType.BaseType!=typeof(LoggerService))
                {
                    throw new Exception("Wrong Logger Type");
                }
                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            }
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if (_loggerService!=null)
            {
                _loggerService.Error(args.Exception);
            }
            base.OnException(args);
        }
    }
}
