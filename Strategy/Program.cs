using Strategy.Common.Services;
using Strategy.Common.Storage;

var people = PeopleDataStore.People;

var fileWriter = new FileWriter();

fileWriter.Write(people, "people.csv");
fileWriter.Write(people, "people.json");
fileWriter.Write(people, "people.xml");
fileWriter.Write(people, "people.yaml");
fileWriter.Write(people, "people.txt");
