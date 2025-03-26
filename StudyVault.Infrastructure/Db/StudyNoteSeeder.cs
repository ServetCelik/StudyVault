using Bogus;
using StudyVault.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyVault.Infrastructure.Db
{
    public static class StudyNoteSeeder
    {
        public static  List<StudyNote> SeedStudyNote(int count = 50)
        {
            var faker = new Faker<StudyNote>()
                .CustomInstantiator(f => new StudyNote(
                    title: f.Lorem.Sentence(),
                    content: f.Lorem.Paragraphs(2),
                    summary: f.Lorem.Sentences(1),
                    subject: f.PickRandom(new[] { "Math", "CS", "History", "Biology", "Physics" }),
                    tags: f.Make(3, () => f.Hacker.Noun()).ToList(),
                    difficulty: f.PickRandom(new[] { "Beginner", "Intermediate", "Advanced" }),
                    authorName: f.Name.FullName()
                ));

            return faker.Generate(count);
        }
    }
}
