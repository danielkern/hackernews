import { Component,  OnInit } from '@angular/core';
import { Story } from '../models/story.model';
import { StoryService } from '../services/story.service';
import { ActivatedRoute } from '@angular/router';
import { StringHelper } from '../helpers/string.helper';
import { StoryTypes } from '../models/storyTypesEnum.model';

@Component({
  selector: 'stories',
  templateUrl: './stories.component.html',
  styleUrls: ['./stories.component.css'],
  providers: [StoryService]
})
export class StoriesComponent implements OnInit {
  public stories: Story[] = [];
  public storyTypeName: string;
  public pageSize: number = 25;
  public storyType: StoryTypes;
  public lastStoryId: number;
  public loading: boolean;

  constructor(private storyService: StoryService, private route: ActivatedRoute, private stringHelper: StringHelper) {
  }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.setTitle(params);
      this.setStoryType(params);
      this.resetStories();
      this.loadStories();
    });
  }

  loadMore(e): void {
    document.querySelector('.loading-element em').scrollIntoView();
    this.loadStories();
  }

  onLoadMoreQuantityChanged(e) {
    this.pageSize = e.currentTarget.value as number;
  }

  private loadStories(): void {
    this.loading = true;
    this.storyService.get(this.storyType, this.lastStoryId, this.pageSize).subscribe(result => {
      this.loading = false;
      this.stories = this.stories.concat(result);
      this.lastStoryId = this.stories.length ? this.stories[this.stories.length - 1].id : 0;
    }, error => console.error(error));
  }

  private resetStories(): void {
    this.stories = [];
    this.lastStoryId = 0;
  }

  private setTitle(params: any): void {
    this.storyTypeName = this.stringHelper.capitalizeFirstLetter(params['storyType']);
  }

  private setStoryType(params: any): void {
    switch (params['storyType']) {
      case 'ask':
        this.storyType = StoryTypes.AskStories;
        break;
      case 'best':
        this.storyType = StoryTypes.BestStories;
        break;
      case 'job':
        this.storyType = StoryTypes.JobStories;
        break;
      case 'show':
        this.storyType = StoryTypes.ShowStories;
        break;
      case 'top':
        this.storyType = StoryTypes.TopStories;
        break;
      case 'new':
      default:
        this.storyType = StoryTypes.NewStories;
        break;
    }
    
  }
}
