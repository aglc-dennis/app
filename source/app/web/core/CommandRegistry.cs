using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
  public class CommandRegistry : IFindCommandsToProcessRequests
  {
      private readonly IEnumerable<IProcessOneRequest> all_commands;
      private readonly ICreateASpecialCaseWhenACommandIsNotFound special_case;


      public CommandRegistry(IEnumerable<IProcessOneRequest> all_commands, ICreateASpecialCaseWhenACommandIsNotFound specialCase)
      {
          this.all_commands = all_commands;
          special_case = specialCase;
      }

      public IProcessOneRequest get_command_that_can_process(IProvideDetailsAboutARequest request)
      {
          var result = all_commands.FirstOrDefault(x => x.can_process(request));

          if (result == null)
          {
              return special_case.Invoke(request);
          }

          return result;
      }
  }
}