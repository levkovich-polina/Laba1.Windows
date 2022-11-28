using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_LABA
{
    public partial class ScreenPartWatcher
    {
        private readonly FormPositionWatcher _formPositionWatcher;
        public event Action<ScreenPart> ScreenPartChanged;

        public ScreenPartWatcher(FormPositionWatcher formPositionWatcher)
        {
            _formPositionWatcher = formPositionWatcher;
            _formPositionWatcher.FormMoved += _formPositionWatcher_FormMoved;
        }

        private void _formPositionWatcher_FormMoved(Point formPosition)
        {
            throw new NotImplementedException();
        }
    }
}