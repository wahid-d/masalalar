using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.LibraryManagement.Exceptions
{
    public class MemberNotFoundException : Exception
    {
        public override string Message => "Member is not found";
    }
}
