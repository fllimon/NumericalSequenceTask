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

        private long _numberSequence = -1;

        #endregion

        #region ======------ CTOR ------=======

        public NumericalSequence(long numberSequence)
        {
            _numberSequence = numberSequence;
        }

        #endregion

        #region ======----- PROPERTIES ------=====

        public long NumberSequence
        {
            get
            {
                return _numberSequence;
            }

            private set
            {
                _numberSequence = value;
            }
        }

        #endregion

        public IEnumerable<long> GetSequence()
        {
            return this;
        }

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
            private readonly NumericalSequence _sequence;
            private bool _isPosition;

            public NumericalIterator(NumericalSequence sequence)
            {
                _sequence = sequence;
                _currentValue = 2;
                _isPosition = false;
            }

            long IEnumerator<long>.Current => _currentValue;

            public object Current => _currentValue;

            public bool MoveNext()
            {
                if (_isPosition)
                {
                    _currentValue *= _currentValue;
                }
                _isPosition = true;

                return _currentValue < _sequence._numberSequence;
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
