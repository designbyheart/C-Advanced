using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Warriors_Wizards
{
    public  abstract class Character
    {
        protected bool IsVulnerarble;

        public abstract string ToString();
        public abstract void DamagePoints(Character target);

        public bool Vulnerable() {
            return this.IsVulnerarble;
        }
        public Character() { 
            IsVulnerarble = true;
        }
    }

    public class Warrior : Character
    {
        public override void DamagePoints(Character target)
        {
            Console.WriteLine("Warrior damage points: {0} {1}", target.ToString(), target.Vulnerable()  ? 10 : 6);
        }

        public override string ToString()
        {
            return "Warrior";
        }

        public Warrior()
        {
            this.IsVulnerarble = false;
        }
    }

    public class Wizard : Character
    {
        protected bool IsSpellPrepared = false;
        public override void DamagePoints(Character target)
        {
            Console.WriteLine("damage points {0} {1}", target.ToString(), this.IsSpellPrepared ? 12 : 3);
            this.IsVulnerarble = true;
        }

        public override string ToString()
        {
            return "Wizard";
        }

        public void PrepareSpell() {
            this.IsVulnerarble = false;
            this.IsSpellPrepared = true;
        }

        public Wizard()
        {
            this.IsVulnerarble = true;
        }
    }
}
