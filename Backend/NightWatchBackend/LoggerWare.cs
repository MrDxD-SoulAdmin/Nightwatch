namespace NightWatchBackend
{
    public class LoggerWare 
    {
        private readonly RequestDelegate _next;

        public LoggerWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            try{
                await _next(context);
            }catch(Exception ex) {
                StreamReader s = new StreamReader(context.Request.Body);
                Console.WriteLine(ex.ToString());
                Console.WriteLine(s.ReadToEnd());
               // context.Response.StatusCode = 500;
            }
            
        }
    }
}
