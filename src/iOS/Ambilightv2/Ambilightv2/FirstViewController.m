//
//  FirstViewController.m
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 15/04/12.
//  Copyright (c) 2012. All rights reserved.
//

#import "FirstViewController.h"
#import "AmbiConnection.h"

@interface FirstViewController ()

@end

@implementation FirstViewController
@synthesize StopButton;
@synthesize StartButton;
@synthesize ErrorLabel;
@synthesize SegmentFxBtn;
@synthesize StopFxBtn;


// Code executed when view is loaded
- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    [SegmentFxBtn setSelectedSegmentIndex:UISegmentedControlNoSegment];
    NSLog(@"Openingsscherm geladen");
    
    
}

// Code executed when view is unloaded
- (void)viewDidUnload
{
    [self setStopButton:nil];
    [self setErrorLabel:nil];
    [self setStartButton:nil];
    [self setSegmentFxBtn:nil];
    [self setStopFxBtn:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation {
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

// Action Start Ambilight
- (IBAction)StartAmbilight:(id)sender {
    NSLog(@"Start de Ambilight...");
    
    AmbiConnection *ambiConnection = [AmbiConnection sharedConnection];
    if([ambiConnection isConnected]) {
        NSLog(@"Verstuurt startbericht...");
        [ambiConnection sendMessage:@"StartAmbilight"];
        ErrorLabel.text = @"";
    } else {
        NSLog(@"Ambilight is niet verbonden...");
        ErrorLabel.text = @"Er zijn connectieproblemen...";
    }
}

// Action Stop Ambilight
- (IBAction)StopAmbilight:(id)sender { 
    NSLog(@"Stop Ambilight");
    
    AmbiConnection *ambiConnection = [AmbiConnection sharedConnection];
    if([ambiConnection isConnected]) {
        NSLog(@"Verstuurt stopbericht...");
        [ambiConnection sendMessage:@"StopAmbilight"];
        ErrorLabel.text = @"";
    } else {
        NSLog(@"Ambilight is niet verbonden...");
        ErrorLabel.text = @"Er zijn connectieproblemen...";
    }
}

// Action Start Effects
- (IBAction)startFx:(id)sender {
    AmbiConnection *ambiConnection = [AmbiConnection sharedConnection];
    
    if(SegmentFxBtn.selectedSegmentIndex == 0) {
        [ambiConnection sendMessage:@"StartFxCycle"];
    }
    if(SegmentFxBtn.selectedSegmentIndex == 1) {
        [ambiConnection sendMessage:@"StartFxStrobe"];
    }
    if(SegmentFxBtn.selectedSegmentIndex == 2) {
        [ambiConnection sendMessage:@"StartFxPolice"];
    }
    
}

// Action stop the effects
- (IBAction)stopFx:(id)sender {
    [SegmentFxBtn setSelectedSegmentIndex:UISegmentedControlNoSegment];
    AmbiConnection *ambiConnection = [AmbiConnection sharedConnection];
    [ambiConnection sendMessage:@"StopFx"];
}

@end
