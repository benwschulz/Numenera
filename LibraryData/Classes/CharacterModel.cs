using LibraryData.DbData;
using System.Collections.Generic;
using System.Linq;

namespace LibraryData
{
    public class CharacterModel
    {
        public Character characterData;
        public List<Advancement> advancementData;
        public List<Cypher> cyphers;
        public List<Ability> abilities;
        
        public List<Skill> mightSkills;
        public List<Skill> speedSkills;
        public List<Skill> intellectSkills;

        public List<Inventory> equipment;
        public List<Inventory> artifacts;
        public List<Inventory> oddities;

        public CharacterModel(int id)
        {
            using (libraryEntities db = new libraryEntities())
            {
                characterData = db.Characters.Where(c => c.Id == id).First();
                advancementData = db.Advancements.Where(a => a.CharacterID == id).ToList();
                cyphers = db.Cyphers.Where(c => c.CharacterID == id).ToList();
                
                getSkillLists(id, db);
                getInventoryLists(id, db);
                getAbilitiesList(id, db);
            }
        }

        private void getSkillLists(int id, libraryEntities db)
        {
            mightSkills = db.Skills.Where(s =>
            s.CharacterID == id && s.Type == "Might").ToList();
            
            speedSkills = db.Skills.Where(s =>
            s.CharacterID == id && s.Type == "Speed").ToList();

            intellectSkills = db.Skills.Where(s =>
            s.CharacterID == id && s.Type == "Intellect").ToList();
        }

        private void getInventoryLists(int id, libraryEntities db)
        {
            equipment = db.Inventories.Where(i =>
            i.CharacterID == id && i.Type == "Equipment").ToList();

            artifacts = db.Inventories.Where(i =>
            i.CharacterID == id && i.Type == "Artifact").ToList();

            oddities = db.Inventories.Where(i =>
            i.CharacterID == id && i.Type == "Oddity").ToList();
        }

        private void getAbilitiesList(int id, libraryEntities db)
        {
            abilities = (from ability in db.Abilities
                        join characters in db.CharacterAbilities
                        on ability.Id equals characters.AbilityID
                        where characters.CharacterID == id
                        select ability).ToList();   
        }
    }
}
