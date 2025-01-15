using Grpc.Core;

namespace Frostvein.CommunicationServer
{
    public class CommunicationServiceImpl : CommunicationService.CommunicationServiceBase
    {
        private readonly WorldServerManager _serverManager = new();

        public override Task<RegisterResponse> RegisterServer(RegisterRequest request, ServerCallContext context)
        {
            var success = _serverManager.RegisterServer(request.ServerName, request.Ip, request.Port);

            return Task.FromResult(new RegisterResponse
            {
                Message = success ? "Server registered successfully." : "Server registration failed.",
                Success = success
            });
        }

        public override Task<SyncResponse> SyncData(SyncRequest request, ServerCallContext context)
        {
            _serverManager.BroadcastData(request.Data);

            return Task.FromResult(new SyncResponse
            {
                Status = "Data broadcasted to all servers."
            });
        }

        public override Task<HeartbeatResponse> Heartbeat(HeartbeatRequest request, ServerCallContext context)
        {
            _serverManager.UpdateHeartbeat(request.ServerName);

            return Task.FromResult(new HeartbeatResponse
            {
                Status = "Heartbeat received."
            });
        }
    }
}
