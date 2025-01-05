using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Application.Pipelines.Performance;

//Bir Command veya Query için performansı ölçmek için kullanılan PipelineBehavior
public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, IPerformanceRequest
{
    private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;

    public PerformanceBehavior(ILogger<PerformanceBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        //Kronometreyi response dönmeden önce başlat
        var stopWatch = Stopwatch.StartNew();
        TResponse response = await next();
        stopWatch.Stop();

        if (stopWatch.ElapsedMilliseconds > 500)
        {
            //Eğer işlem 500 milisaniyeden fazla sürdüyse logla

            _logger.LogWarning("{RequestName} {ElapsedMiliseconds}", typeof(TRequest).Name, stopWatch.ElapsedMilliseconds);
        }
        return response;
    }

}


