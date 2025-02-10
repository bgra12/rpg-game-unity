using System;

[Serializable]
public class FSMTransition
{
        public FSMDecision decision;
        public string trueState;
        public string falseState;
}
