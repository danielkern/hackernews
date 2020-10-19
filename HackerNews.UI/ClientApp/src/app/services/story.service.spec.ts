import { StoryService } from './story.service';
import { StoryTypes } from '../models/storyTypesEnum.model';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {
  TestBed
} from '@angular/core/testing';
import { environment } from '../../environments/environment';

describe('StoryService', () => {
  let service: StoryService;
  let httpMock: HttpTestingController;
  const baseUrl: string = environment.production ? 'https://hacker-news-api-app.azurewebsites.net' : 'https://localhost:44377';

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [StoryService]
    });
    service = TestBed.get(StoryService);
    httpMock = TestBed.get(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be able to get stories from the API', () => {
    const expectedStories: any[] = [
      {
        id: 1,
        title: 'Story 1',
      },
      {
        id: 1,
        title: 'Story 2'
      },
    ];

    const storyType = StoryTypes.NewStories;
    const lastItemId = 0;
    const pageSize = 10;

    service.get(storyType, lastItemId, pageSize).subscribe((stories) => {
      expect(stories.length).toBe(2);
      expect(stories[0].title).toBe('Story 1');
      expect(stories[1].title).toBe('Story 2');
    });

    const request = httpMock.expectOne(`${baseUrl}/api/story?storyType=${StoryTypes.NewStories}&lastItemId=${lastItemId}&size=${pageSize}`);
    expect(request.request.method).toBe('GET');
    request.flush(expectedStories);
  });

  it('should be able to get story by ID from the API', () => {
    const expectedStory: any = {
        id: 1,
        title: 'Story 1',
      };

    const storyId = 0;

    service.getById(storyId).subscribe((story) => {
      expect(story.id).toBe(1);
      expect(story.title).toBe('Story 1');
    });

    const request = httpMock.expectOne(`${baseUrl}/api/story/${storyId}`);
    expect(request.request.method).toBe('GET');
    request.flush(expectedStory);
  });

  it('search', () => {
    expect(service.search()).toBeNull();
  });
});
