//
//  AmbiConnection.m
//  Ambilightv2
//
//  Created by Jesse Dobbelaere on 28/04/12.
//  Copyright (c) 2012. All rights reserved.
//

#import "AmbiConnection.h"

// Singleton
static AmbiConnection *sharedConnection = nil;


@implementation AmbiConnection 

// Generate getters en setters
@synthesize ipAdres;


// Constructor
+ (AmbiConnection *)sharedConnection {
    if(sharedConnection == nil){
        sharedConnection = [[super allocWithZone:NULL] init];
    }
    return sharedConnection;
}


// Initialiseer de netwerkverbinding
- (void)initNetworkCommunication {
    CFReadStreamRef readStream;
    CFWriteStreamRef writeStream;
    
    // Bind 2 streams to a host and a port
    CFStreamCreatePairWithSocketToHost(NULL, (__bridge CFStringRef)self.ipAdres, 8001, &readStream, &writeStream);
    inputStream = (__bridge NSInputStream *)readStream;
    outputStream = (__bridge NSOutputStream *)writeStream;
    
    // Schrijf op console 
    NSLog(@"Verbinding instellen met ipadres: %@", self.ipAdres);
    
    // Set delegates    
    [inputStream setDelegate:self];
    [outputStream setDelegate:self];
    
    // Schedule our input streams to have processing in the run loop
    [inputStream scheduleInRunLoop:[NSRunLoop currentRunLoop] forMode:NSDefaultRunLoopMode];
    [outputStream scheduleInRunLoop:[NSRunLoop currentRunLoop] forMode:NSDefaultRunLoopMode];
}

// Open de verbinding
- (BOOL) openConnection {
    // open the connection
    @try {
        [inputStream open];
        [outputStream open];
    }
    @catch (NSException *e) {
        return NO;
    }
    
    return YES;
}

- (BOOL) isConnected {
    if(inputStream && outputStream) {
        return YES;
    } else {
        return NO;
    }
}

// Zend een bericht
- (void) sendMessage:(NSString *) message {
    NSString *response  = [NSString stringWithFormat:@"msg:%@", message];
	NSData *data = [[NSData alloc] initWithData:[response dataUsingEncoding:NSASCIIStringEncoding]];
	[outputStream write:[data bytes] maxLength:[data length]];
}


@end
