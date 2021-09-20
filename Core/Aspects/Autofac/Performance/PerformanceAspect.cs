using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.SendMail;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Core.Aspects.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        /* Aspect'in kullanıldığı alanda hedef zaman belirlitilir. Ex: [PerformanceAspect(5)]. Bu hedef zaman (5) aşıldığı takdirde sistem uyarı gönderir  */
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
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                SendMail sendMail = new SendMail();
                sendMail.Send("gorkem_akkaya@hotmail.com", "Sistem Performansı",
                               $"Çalışan Metod : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name} \n" +
                               $"Çalışmasında kullanılan süre(ms): {_stopwatch.Elapsed.TotalSeconds} sn \n" +
                               $"Hedef Zaman: {_interval} sn");
            }
            _stopwatch.Reset();
        }
    }
}