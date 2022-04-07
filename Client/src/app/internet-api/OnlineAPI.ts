
   

        export interface From {
            url: string;
            name: string;
        }
    
        export interface Subclass {
            url: string;
            name: string;
        }
        export interface ProficiencyChoice {
            choose: number;
            type: string;
            from: From[];
        }
        export interface TheClass {
            _id: string;
            index: string;
            name: string;
            hit_die: number;
            proficiency_choices: ProficiencyChoice[];
            subclasses: Subclass[];
            url: string;
        }
    
    
 


        



            export interface AbilityBonus {
                name: string;
                url: string;
                bonus: number;
            }
        
            export interface StartingProficiency {
                url: string;
                name: string;
            }
        
            export interface Language {
                url: string;
                name: string;
            }
        
            export interface Trait {
                name: string;
                url: string;
            }
        
            export interface Subrace {
                url: string;
                name: string;
            }
        
            export interface TheRace {
                _id: string;
                index: string;
                name: string;
                speed: number;
                ability_bonuses: AbilityBonus[];
                age: string;
                alignment: string;
                size: string;
                size_description: string;
                starting_proficiencies: StartingProficiency[];
                languages: Language[];
                language_desc: string;
                traits: Trait[];
                subraces: Subrace[];
                url: string;
            }
        
        
        
        

        
        


            export interface School {
                name: string;
                url: string;
            }
        
            export interface Class {
                name: string;
                url: string;
            }
        
            export interface Subclass {
                name: string;
                url: string;
            }
        
            export interface TheSpell {
                _id: string;
                index: string;
                name: string;
                range: string;
                material: string;
                ritual: boolean;
                duration: string;
                concentration: boolean;
                casting_time: string;
                level: number;
                school: School;
                url: string;
            }
        

            