using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Enums;
namespace WebApplication2.ViewModels
{
    public class frindRequestDetail
    {
                        public string  Id { set; get;  }
                
                        public  string ImagePath  { set; get;  }

                     public string UserName{ set; get;  }
                     public string City { set; get;  }
                   public string     Email { set; get;  }
                    public string    RequestedID { set; get;  }
                     public string     RequesterID{ set; get;  }
                    
                      public FriendState State { set; get;  }
    }
}
