using System;
using System.Collections;
using System.Collections.Generic;

namespace app.web.core
{
  public class CommandRegistry : IFindCommandsToProcessRequests
  {
      private IEnumerable<IProcessOneRequest> requests;

      public CommandRegistry(IEnumerable<IProcessOneRequest> requests)
      {
          this.requests = requests;
      }

      public IProcessOneRequest get_command_that_can_process(IProvideDetailsAboutARequest request)
    {
          foreach (var oneRequest in requests)
          {
              if (oneRequest.can_process(request))
              {
                  return oneRequest;
              }
          }

          throw new Exception("WHAAAAT I COULDN'T FIND ANYTHING SO I SHOULD THROW AN EXCEPTION DUE TO OUR ASSUMPTIONS");
    }
  }
}