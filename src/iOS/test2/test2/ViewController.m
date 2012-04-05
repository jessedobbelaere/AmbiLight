//
//  ViewController.m
//  test2
//
//  Created by Jesse Dobbelaere on 29/03/12.
//  Copyright (c) 2012 __MyCompanyName__. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController
@synthesize inputNameField;
@synthesize joinView;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    [self initNetworkCommunication];
}

- (void)viewDidUnload
{
    [self setInputNameField:nil];
    [self setJoinView:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

- (void)initNetworkCommunication {
    CFReadStreamRef readStream;
    CFWriteStreamRef writeStream;
    
    // Bind 2 streams to a host and a port
    CFStreamCreatePairWithSocketToHost(NULL, (CFStringRef)@"192.168.1.112", 8001, &readStream, &writeStream);
    inputStream = (__bridge NSInputStream *)readStream;
    outputStream = (__bridge NSOutputStream *)writeStream;
    
    // Set delegates    
    [inputStream setDelegate:self];
    [outputStream setDelegate:self];
    
    // Schedule our input streams to have processing in the run loop
    [inputStream scheduleInRunLoop:[NSRunLoop currentRunLoop] forMode:NSDefaultRunLoopMode];
    [outputStream scheduleInRunLoop:[NSRunLoop currentRunLoop] forMode:NSDefaultRunLoopMode];
    
    // open the connection
    [inputStream open];
    [outputStream open];
}

- (IBAction)joinChat:(id)sender {
    NSString *response  = [NSString stringWithFormat:@"msg:%@", inputNameField.text];
	NSData *data = [[NSData alloc] initWithData:[response dataUsingEncoding:NSASCIIStringEncoding]];
	[outputStream write:[data bytes] maxLength:[data length]];
}
@end
