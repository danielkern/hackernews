import { browser, by, element, until, ExpectedConditions } from 'protractor';

export class AppPage {



  navigateTo() {
    return browser.get('/');
  }

  getMainHeading() {
    return element(by.css('app-root h1')).getText();
  }

  navigateToUrl(url: string) {
    return browser.get(url);
  }

  clickLoadMore() {
    return this.getLoadMoreButton().click();
  }

  getLoadMoreButton() {
    return element(by.css('.btn-load-more'));
  }

  async getPageSizeValue() {
    const pageSizeElement = element(by.css('.page-size-25'));
    return await pageSizeElement.getAttribute('value');
  }

  async waitForElementByCSS(cssSelector: string, waitMilliseconds: number) {
    const EC = ExpectedConditions;
    const locator = by.css(cssSelector);
    const elementFinder = element(locator);
    return await browser.driver.wait(EC.presenceOf(elementFinder), waitMilliseconds, `Element could not be located within wait time of ${waitMilliseconds} ms.`);
  }

  async waitForElementByXPath(xpath: string, waitMilliseconds: number) {
    const EC = ExpectedConditions;
    const locator = by.xpath(xpath);
    const elementFinder = element(locator);
    return await browser.wait(until.elementLocated(EC.presenceOf(elementFinder)), waitMilliseconds, `Element could not be located within wait time of ${waitMilliseconds} ms.`);
  }
}
