const width = 100;
const height = 100;

simulation.environmentSeed = 20200806;
simulation.movementSeed = 2232;
simulation.size = new size(width, height);
simulation.minimumAttractorStrength = 1;
simulation.maximumAttractorStrength = 128;
simulation.minimumRepellentStrength = 1;
simulation.maximumRepellentStrength = 128;
simulation.attractorCollisionAction = CollisionAction.ReduceSelf;
simulation.repellentCollisionAction = CollisionAction.ReduceOther;
simulation.respawnAttractor = true;
simulation.wrap = true;
simulation.binaryFission = false
simulation.solidStrands = false;
simulation.attrition = false;
simulation.mobileRepellents = true;

simulation.Reset();

for (let index = 0; index < width; index++) 
{
  var nox

  nox = new chemoeffector();
  nox.Position = new point(index, 1);
  nox.Strength = 10;
  nox.Heading = new point(0, 1);
  //nox.CollisionAction = CollisionAction.DestroyOther;

  simulation.Repellents.Add(nox);
}

for (let index = 0; index < 5; index++) {
  simulation.AddAttractor();
}

for (let index = 0; index < 100; index++) {
  simulation.AddStrand();
}

// var food;

// food = new chemoeffector();
// food.Position = new point(width / 2, height / 2);
// //food.Strength = 2147483647
// food.Strength = width;

// simulation.Attractors.add(food);

// var strand;

// strand = new strand();
// strand.Position = new point(width / 4, height / 4);
// strand.Heading = new point(1, 0);

// simulation.Strands.add(strand);