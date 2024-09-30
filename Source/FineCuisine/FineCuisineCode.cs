using RimWorld;
using Verse;

namespace FineCuisine
{
    public class ThingDef_OneStarMeal : ThingWithComps
    {
        protected override void PostIngested(Pawn ingester)
        {
            //Log.Message("DEBUG1");
            //Log.Message("DEBUG1 " + this.def.ingestible.preferability);
            if (this.def.defName == "OneStarMeal")
            {
                foreach (Thought_Memory t in ingester.needs.mood.thoughts.memories.Memories)
                {
                    if (t.def.defName == "AteThreestarMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                    if (t.def.defName == "AteTwostarMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                    if (t.def.defName == "AteLavishMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                }
            }
        }
    }

    public class ThingDef_TwoStarMeal : ThingWithComps
    {
        protected override void PostIngested(Pawn ingester)
        {
            //Log.Message("DEBUG2 " + this.def.ingestible.preferability);

            if (this.def.defName == "TwoStarMeal")
            {

                foreach (ThingDef c in this.GetComp<CompIngredients>()?.ingredients)
                {
                    if (c.defName.Contains("Plate")) {
                        ThingDef thingDef = ThingDef.Named(c.defName);

                        Thing thing = ThingMaker.MakeThing(thingDef, null);

                        GenSpawn.Spawn(thing, ingester.Position, ingester.Map);
                    }
                    
                }

                foreach (Thought_Memory t in ingester.needs.mood.thoughts.memories.Memories)
                {
                    //Log.Message(ingester.def.defName+" t:"+t.def.defName);
                    if (t.def.defName == "AteOnestarMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                    if (t.def.defName == "AteThreestarMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                    if (t.def.defName == "AteLavishMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                }
            }
        }

        public override void Destroy(DestroyMode mode)
        {
            foreach (ThingDef c in this.GetComp<CompIngredients>()?.ingredients)
            {
                //Log.Message("try to place plate");
                if (c.defName.Contains("Plate"))
                {
                    ThingDef thingDef = ThingDef.Named(c.defName);

                    Thing thing = ThingMaker.MakeThing(thingDef, null);

                    if (this.Map!=null) {
                        //Log.Message("map: "+this.Map);
                        GenSpawn.Spawn(thing, this.Position, this.Map);
                    }
                    
                }

            } 
                
            base.Destroy(mode);
        }


    }

    public class ThingDef_ThreeStarMeal : ThingWithComps
    {
        
        protected override void PostIngested(Pawn ingester)
        {
            this.def.ingestible.optimalityOffsetHumanlikes += 10;
            //Log.Message("DEBUG4");
            //Log.Message("DEBUG4 " + this.def.ingestible.preferability);
            //Log.Message("DEBUG4 " + this.def.ingestible.optimalityOffsetHumanlikes);
            foreach (Thought_Memory t in ingester.needs.mood.thoughts.memories.Memories)
            {
                //Log.Message(ingester.def.defName+" t:"+t.def.defName);
                if (t.def.defName == "AteOnestarMeal")
                {
                    t.age = 60000; //1day == 60k ticks
                }
                if (t.def.defName == "AteTwostarMeal")
                {
                    t.age = 60000; //1day == 60k ticks
                }
                if (t.def.defName == "AteLavishMeal")
                {
                    t.age = 60000; //1day == 60k ticks
                }
            }

            foreach (ThingDef c in this.GetComp<CompIngredients>()?.ingredients)
            {
                if (c.defName.Contains("Plate"))
                {

                    ThingDef thingDef = ThingDef.Named(c.defName);

                    Thing thing = ThingMaker.MakeThing(thingDef, null);

                    GenSpawn.Spawn(thing, ingester.Position, ingester.Map);
                }

            }
        }

        public override void Destroy(DestroyMode mode)
        {
            //Log.Message("DEBUG5");
            foreach (ThingDef c in this.GetComp<CompIngredients>()?.ingredients)
            {
                if (c.defName.Contains("Plate"))
                {

                    ThingDef thingDef = ThingDef.Named(c.defName);

                    Thing thing = ThingMaker.MakeThing(thingDef, null);

                    if (this.Map != null)
                    {
                        //Log.Message(this.Map+" hello?");
                        GenSpawn.Spawn(thing, this.Position, this.Map);
                    }
                }

            }

            base.Destroy(mode);
        }
    }

    public class ThingDef_MealLavish : ThingWithComps
    {
        protected override void PostIngested(Pawn ingester)
        {

            //Log.Message(this.def.defName);

            if (this.def.defName == "MealLavish")
            {

                foreach (Thought_Memory t in ingester.needs.mood.thoughts.memories.Memories)
                {
                    //Log.Message(ingester.def.defName+" t:"+t.def.defName);
                    if (t.def.defName == "AteOnestarMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                    if (t.def.defName == "AteTwostarMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                    if (t.def.defName == "AteThreestarMeal")
                    {
                        t.age = 60000; //1day == 60k ticks
                    }
                }
            }
        }
    }

}
