using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.SendMail;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception, ISendMail
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            //if (_stopwatch.Elapsed.TotalSeconds > _interval)
            //{
                SendMail sendMail = new SendMail();
                sendMail.Send("gorkemgenarakkaya@gmail.com", "Sanane12", "ADMIN", "gorkem_akkaya@hotmail.com", "Sistem Performansı",
                     $"Performance : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.Seconds}",
                     "smtp.gmail.com", 587);
            //}
            _stopwatch.Reset();
        }
    }
}
