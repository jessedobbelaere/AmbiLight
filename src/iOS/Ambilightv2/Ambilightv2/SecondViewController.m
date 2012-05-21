//
//  SecondViewController.m
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 15/04/12.
//  Copyright (c) 2012 Dobbelaere Auto-Elektriciteit. All rights reserved.
//

#import "SecondViewController.h"
#import "AmbiConnection.h"
#include <arpa/inet.h>


@class AmbiConnection;
@interface SecondViewController ()

@end

@implementation SecondViewController
@synthesize ipAdresInput;
@synthesize errorLabel;
@synthesize connectButton;

- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    
    NSLog(@"Settings geladen");        
}

- (void)viewDidUnload
{
    [self setIpAdresInput:nil];
    [self setConnectButton:nil];
    [self setErrorLabel:nil];
    [super viewDidUnload];
    // Release any retained subviews of the main view.
}

- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation
{
    return (interfaceOrientation != UIInterfaceOrientationPortraitUpsideDown);
}

-(IBAction)ConnectPressed:(id)sender {    
    [ipAdresInput resignFirstResponder]; // Hide the keyboard
    
    AmbiConnection *ambiConnection = [AmbiConnection sharedConnection];
    
    if([self isIp:ipAdresInput.text]) {
        ambiConnection.ipAdres = ipAdresInput.text;
        NSLog(@"I will try to make a connection with ip: %@", ambiConnection.ipAdres);
        
        [ambiConnection initNetworkCommunication];
        if([ambiConnection openConnection]) {
            NSLog(@"Connected!");
        } else {
            NSLog(@"Foutje!");
        }
    }
    
}

-(IBAction)textFieldReturn:(id)sender {
    [sender resignFirstResponder];
}

-(IBAction)backgroundTouched:(id)sender {
    [ipAdresInput resignFirstResponder];
}

- (BOOL)isIp:(NSString*)string{
    struct in_addr pin;
    int success = inet_aton([string UTF8String],&pin);
    if (success == 1) return TRUE;
    return FALSE;
}


@end
