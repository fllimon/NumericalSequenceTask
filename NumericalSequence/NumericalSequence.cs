using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalSequenceLib
{
    public class NumericalSequence : IEnumerable<long>
    {
        #region ======------ PRIVATE DATA -----======

        private long _numberSequenceStart = -1;
        private long _numberSequenceFinish = -1;

        #endregion

        #region ======------ CTOR ------=======

        public NumericalSequence(long numberSequenceStart, long numberSequenceFinish)
        {
            _numberSequenceStart = numberSequenceStart;
            _numberSequenceFinish = numberSequenceFinish;
        }

        #endregion

        public IEnumerator<long> GetEnumerator()
        {
            return new NumericalIterator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NumericalIterator(this);
        }

        private struct NumericalIterator : IEnumerator<long>
        {
            private long _currentValue;
            private long _numberBeforPower;
            private readonly NumericalSequence _sequence;
            private bool _isPosition;

            public NumericalIterator(NumericalSequence sequence)
            {
                _sequence = sequence;
                _currentValue = _sequence._numberSequenceStart;
                _numberBeforPower = _currentValue;
                _isPosition = false;
            }

            long IEnumerator<long>.Current => _numberBeforPower;

            public object Current => _numberBeforPower;

            public bool MoveNext()
            {
                _numberBeforPower++;
                _currentValue = _numberBeforPower;

                if (_isPosition)
                {
                    _currentValue *= _currentValue;
                }

                _isPosition = true;
                
                return _currentValue < _sequence._numberSequenceFinish;
            }

            public void Reset()
            {
                _currentValue = 0;
            }

            public void Dispose()
            {
            }
        }
    }
}
