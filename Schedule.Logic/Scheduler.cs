using System;
using System.IO;
using Prolog;
using Prolog.Code;

namespace Schedule.Logic
{
    public class Scheduler
    {
        private Program _program;
        private Query _query;
        private PrologMachine _machine;

        public Program Program
        {
            get
            {
                if (_program == null)
                {
                    string path = "~/Prolog/Schedule.prolog";
                    if (!File.Exists(path))
                        throw new FileNotFoundException(string.Format("{0} not found.  Consider updating SamplesFolder setting during program development.", path));
                    Program program = Program.Load(path);
                    _program = program;
                }
                return _program;
            }
        }

        public Query Query
        {
            get
            {
                if (_query == null)
                {
                    CodeSentence codeSentenceQuery = Parser.Parse(":- solve(X)")[0];
                    Query query = new Query(codeSentenceQuery);

                    _query = query;
                }
                return _query;
            }
        }

        public PrologMachine Machine
        {
            get
            {
                if (_machine == null)
                {
                    PrologMachine machine = PrologMachine.Create(Program, Query);

                    _machine=machine;
                }
                return _machine;
            }
        }

        public void Restart()
        {
            PrologMachine machine = Machine;

            machine.Restart();
        }

        public Schedule Execute()
        {
            PrologMachine machine = Machine;

            if (!machine.CanRunToSuccess)
                return null;

            ExecutionResults executionResults = machine.RunToSuccess();

            if (executionResults != ExecutionResults.Success)
                return null;

            CodeTerm codeTerm = machine.QueryResults.Variables[0].CodeTerm;
            Schedule schedule = Schedule.Create(codeTerm);

            return schedule;
        }
    }
}
