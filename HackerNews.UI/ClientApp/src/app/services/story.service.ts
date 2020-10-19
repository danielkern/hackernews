import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Story } from '../models/story.model';
import { StoryTypes } from '../models/storyTypesEnum.model';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root',
})
export class StoryService {
  constructor(private http: HttpClient) {
  }

  private baseUrl: string = environment.production ? 'https://hacker-news-api-app.azurewebsites.net' : 'https://localhost:44377';

  get(storyType: StoryTypes, lastItemId: number = 0, pageSize: number) {
    return this.http.get<Story[]>(`${this.baseUrl}/api/story?storyType=${storyType}&lastItemId=${lastItemId}&size=${pageSize}`);
  }

  getById(id: number) {
    return this.http.get<Story>(`${this.baseUrl}/api/story/${id}`);
  }

  search() {
    return null;
  }

  create() {
    throw new Error('Not implemented');
  }

  update() {
    throw new Error('Not implemented');
  }

  delete() {
    throw new Error('Not implemented');
  }
}
