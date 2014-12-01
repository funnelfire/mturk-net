using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTurk.DTO
{
    public interface IQuestion
    {
    }

    public partial class ExternalQuestion : IQuestion
    {
    }

    public partial class HTMLQuestion : IQuestion
    {
    }

    public partial class QuestionForm : IQuestion
    {
    }
}
