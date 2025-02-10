using System;

    [Serializable]
    public class FSMState
    {
        public string id;
        public FSMAction[] actions;
        public FSMTransition[] transitions;


        public void updateState(EnemyAI enemyAI)
        {
            executeAction();
            executeTransitions(enemyAI);
        }
        
        private void executeAction()
        {
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].act();
            }
        }

        private void executeTransitions(EnemyAI enemyAI)
        {
            if (transitions != null && transitions.Length > 0)
            {
                for (int i = 0; i < transitions.Length; i++)
                {
                    if (transitions[i].decision.decide())
                    {
                        enemyAI.changeState(transitions[i].trueState);
                    }
                    else
                    {
                        enemyAI.changeState(transitions[i].falseState);
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
