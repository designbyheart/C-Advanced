using System;
using Warriors_Wizards;

namespace WarriorsAndWizards {
    class Program {
        public static void Main(string[] args)
        {
            var warior = new Warrior();
            var wizard = new Wizard();

            wizard.DamagePoints(warior);

            wizard.PrepareSpell();
            wizard.DamagePoints(warior);
            warior.DamagePoints(wizard);
        }
    }

}