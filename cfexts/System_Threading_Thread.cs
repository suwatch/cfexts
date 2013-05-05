using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace cfexts
{
    public class System_Threading_Thread
    {
        //                                   PreEmptive   GC Alloc                Lock
        //       ID  OSID ThreadOBJ    State GC           Context       Domain   Count APT Exception
        //   0    1  265c 001fb680      a020 Enabled  01fd2e7c:01fd2f2c 001c3980     0 MTA
        //   2    2  10e0 001cc078      b220 Enabled  00000000:00000000 001c3980     0 MTA (Finalizer)
        const string regExPattern = " *(?<TID>[^ ]+)"
            + " +(?<ID>[0-9a-f]+)"
            + " (?<OSID>.{5})"
            + " +(?<ThreadOBJ>[0-9a-f]+)"
            + " +(?<State>[0-9a-f]+)"
            + " +(?<GC>[^ ]+)"
            + " +(?<Context>[^ ]+)"
            + " +(?<Domain>[0-9a-f]+)"
            + " +(?<Count>[0-9a-f]+)"
            + " +(?<APT>[^ ]+)"
            + "( +(?<Exception>.+))?";

        Match match;

        System_Threading_Thread(Match match)
        {
            this.match = match;
        }

        public string TID { get { return this.match.Groups["TID"].Value; } }
        public string ID { get { return this.match.Groups["ID"].Value; } }
        public string OSID { get { return this.match.Groups["OSID"].Value.Trim(); } }
        public string ThreadOBJ { get { return this.match.Groups["ThreadOBJ"].Value; } }
        //public override string ToString() { return String.Format("Thread( TID = {0} , ID = {1} , ThreadOBJ = {2} )", TID, ID, ThreadOBJ); }

        public static System_Threading_Thread Parse(string text)
        {
            Match match = ExtensionApis.NewRegex(regExPattern).Match(text);
            if (!match.Success)
            {
                throw ExtensionApis.ThrowExceptionHelper(regExPattern, text, (string)null);
            }
            return new System_Threading_Thread(match);
        }
    }
}
